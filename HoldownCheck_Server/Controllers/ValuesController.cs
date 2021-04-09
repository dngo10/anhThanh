using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<object>> Get()
        {
            var hd_sch = new HoldownData();
            var hd = hd_sch.SimpSonHD.GroupBy(x => x.Name).Select(x => x.First().Name).ToArray();

            var ab_sch = new AnchorData();
            var ab = ab_sch.SimpSonAB.GroupBy(x => x.Name).Select(x => x.First().Name).ToArray();

            var po = WoodPost.getWoodPost().Select(x => x.Name).ToArray();

            var loc = Enum.GetNames(typeof(eLocation));

            return new object[] { hd, po, ab, loc };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(string id)
        {
            return "Gouvis Engineering";
        }

        // GET api/values/Pics
        [HttpGet("pic/{pic_id}")]
        public ActionResult Getpics(string pic_id)
        {
            try
            {
                pic_id = pic_id.ToUpper();
                if (pic_id.Contains("SSTB"))
                    pic_id = "SSTB";
                else if (pic_id.Contains("PAB"))
                    pic_id = "PAB";

                string path = string.Format("./pics/{0}.png", pic_id);
                var arr = System.IO.File.ReadAllBytes(path);
                return File(arr, Image.Gif);
            }catch
            {

            }

            return null;
        }


        // POST api/values       
        [HttpPost]
        public string Post([FromBody] string value)
        {
            var asplit = value.Split(" ");

            var hd_sch = new HoldownData();
            var hd = hd_sch.SimpSonHD.FirstOrDefault(x => x.Name.Equals(asplit[0]));

            var ab_sch = new AnchorData();
            var ab = ab_sch.SimpSonAB.FirstOrDefault(x => x.Name.Equals(asplit[2]));

            var post = new WoodPost() { Name = asplit[1] };
            var loc = (eLocation)Enum.Parse(typeof(eLocation), asplit[3]);
            var fc = int.Parse(asplit[4]);
            var stemwall = int.Parse(asplit[5]);

            var combo = CombineHardware(hd, ab, post, loc, stemwall, fc);

            return JsonConvert.SerializeObject(combo);
        }


        private ComboHardware CombineHardware(HoldownSCH hd, AnchorSCH ab, WoodPost post, eLocation loc, int stemwall, int fc)
        {
            var hd_sch = new HoldownData();
            var ab_sch = new AnchorData();

            HoldownSCH[] allHD = hd_sch.SimpSonHD;
            AnchorSCH[] allAB = ab_sch.SimpSonAB;
            WoodPost[] allPost = WoodPost.getWoodPost();
            post = allPost.FirstOrDefault(x => x.Name.Equals(post.Name));

            var _combo = new ComboHardware() { post = post, Stemwall = stemwall };

            if (hd != null)
            {
                var HDs = allHD.Where(x => x.Name == hd.Name && x.MinWoodThk <= post.Thickness);
                if (HDs != null && HDs.Count() > 0)
                {
                    var HDc = HDs.First();
                    if (HDc.GetType() == typeof(Strap_Holdown))
                    {
                        var sthd = HDs.LastOrDefault
                                    (x => (x as Strap_Holdown).Location == loc
                                    && (x as Strap_Holdown).MinStemwall <= stemwall);
                        _combo.Holdown = sthd;
                    }
                    else if (HDc.GetType() == typeof(Holdown))
                    {
                        if (post.Name.ToUpper().Contains("6X"))
                        {
                            var hdx = HDs.LastOrDefault(x => x.Is6X6);
                            _combo.Holdown = hdx ?? HDs.Last(); ;
                        }
                        else
                        {
                            var hdx = HDs.Last();
                            _combo.Holdown = hdx;
                        }
                    }
                }

            }

            if (_combo.Holdown != null && ab != null)
            {
                var ABs = allAB.Where(x => x.Name == ab.Name);
                if (ABs != null && ABs.Count() > 0 && _combo.Holdown is Holdown)
                {
                    var ABc = ABs.First();
                    if (ABc.GetType() == typeof(SSTB))
                    {
                        var sstb = ABs.LastOrDefault(
                                x => (x as SSTB).Location == loc
                                && (x as SSTB).MinStemwall <= stemwall);
                        _combo.AnchorBolt = sstb;
                    }
                    else if (ABc.GetType() == typeof(PAB))
                    {
                        var _hd = _combo.Holdown as Holdown;
                        var pab = ABs.LastOrDefault(x => x.Dia == _hd.AB_dia && (x as PAB).fc.Equals(fc));
                        _combo.AnchorBolt = pab;

                        _combo.AnchorBolt = ABc;
                    }
                }
            }

            return _combo;
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
