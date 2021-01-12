using DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VO;

namespace API.Controllers
{
    public class SampleController : ApiController
    {
        // GET: api/Sample
        public List<MenuVO> Get()
        {
            MenuDAC dac = new MenuDAC();
            return dac.GetMenus();
        }

        // GET: api/Sample/5
        // Example : https://localhost:44384/api/Sample/5
        public MenuVO Get(int id)
        {
            MenuDAC dac = new MenuDAC();
            return dac.GetMenus()[id];
        }

        // POST: api/Sample
        public HttpResponseMessage Post([FromBody]MenuVO value)
        {
            //DAC단에서 추가 메서드 실행후 결과에 따라 HttpResponseMessage형식으로 반환

            if (2 == 1)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, value.FormName);
                response.Content = new StringContent($"메시지 입력", System.Text.Encoding.Unicode);

                return response;
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }



        }

        // PUT: api/Sample/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Sample/5
        public void Delete(int id)
        {

        }
    }
}
