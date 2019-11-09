using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartCreelBackend.Model;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace SmartCreelBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreelController : ControllerBase
    {
        [HttpGet("getAll")]
        public IEnumerable<Creel> GetAll()
        {
            var dbContext = new SmartcreeldbContext();

            return dbContext.Creel.ToList();
        }

        [HttpPut(@"{creelId}/{machineName}/{isLeftSide}")]
        public string UpdateCreel(int creelId, int machineId, bool isLeftSide = false)
        {
            var dbContext = new SmartcreeldbContext();

            var currentMachine = dbContext.Machine.SingleOrDefault(m => m.Id == machineId);
            var currentCreel = dbContext.Creel.Include("CreelSide").SingleOrDefault(c => c.Id == creelId);

            var creelSide = currentCreel.CreelSide.SingleOrDefault(cs => cs.CreelId == creelId && cs.IsLeftSide == isLeftSide);

            if(creelSide == null)
            {
                creelSide = new CreelSide();
                dbContext.CreelSide.Add(creelSide);
            }

            creelSide.Creel = currentCreel;
            creelSide.Machine = currentMachine;
            creelSide.LoadingTime = DateTime.Now;
            creelSide.IsLeftSide = isLeftSide;

            

            dbContext.SaveChanges();

            return JsonConvert.SerializeObject(currentCreel, Formatting.Indented,
            new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }
    }
}