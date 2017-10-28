using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RockManApi.Models;
using RockManApi.Utils;

namespace RockManApi.Controllers
{
    [Route("api/[controller]")]
    public class RobotController : Controller
    {
        private readonly RobotContext _context;
        
        
        public RobotController(RobotContext context)
        {
            _context = context;

            if (!_context.Robots.Any())
            {
                // seed data
                var filePath = @".\Data\RobotMasters.json";
                var robots = new JsonLoader()
                                .Load<Robot>(filePath)
                                .ToList();

                _context.Robots.AddRange(robots);
                _context.SaveChanges();
            }
        }




        [HttpGet]
        public IEnumerable<Robot> GetAll()
        {
            return _context.Robots.ToList();
        }









        [HttpGet("{id}", Name = "GetRobot")]
        public IActionResult GetById(long id)
        {
            var robot = _context.Robots.FirstOrDefault(r => r.Id == id);

            if (robot == null)
                return NotFound();

            return new ObjectResult(robot);
        }







        [HttpGet("series/{seriesId}")]
        public IEnumerable<Robot> GetBySeries(string seriesId)
        {
            var robots = _context.Robots.Where(r => r.Series.Equals(seriesId));

            return robots.ToList();
        }        
    }
}