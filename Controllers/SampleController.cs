using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.Entities;
using WebAPI.Services.Interfaces;


namespace WebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class SampleController : Controller
    {
        private readonly ICMDs cmd;

        public SampleController(ICMDs cmd)
        {
            this.cmd = cmd;
        }
        
        [HttpGet("ping")]
        public ActionResult<string> Ping(){
            return Ok("pong!");
            
        }

        [HttpPost("insert")]
        public async Task<ActionResult<SampleModel>> Insert(In_SampleModel model){
            var res = await cmd.Insert(model);
            return Created(res.id.ToString(), res);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SampleModel>> Get(int id){
            try{
                return Ok(await cmd.Get(id));
            }
            catch (NullReferenceException){
                return NotFound();
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<SampleModel>> Update(int id, In_SampleModel newModel){
            try{
                return Ok(await cmd.Update(id, newModel));
            }
            catch (NullReferenceException){
                return NotFound();
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id){
            try{
                await cmd.Drop(id);
                return Ok("Resource deleted successfully");
            }
            catch (NullReferenceException){
                return NotFound();
            }
        }
    }
}