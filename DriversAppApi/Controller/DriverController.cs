using DriverAppApi.Model;
using DriverAppApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace  DriverAppApi.Controller;


[ApiController]
[Route("api/[controller]")]
public class DriverController : ControllerBase
{

      private readonly DriverService _driverService;

      public DriverController(DriverService driverService) => _driverService = driverService;


     [HttpGet("{id:length(24)}")]
     public async Task<IActionResult> Get(string id)
     {
        var existingDriver = await _driverService.GetAsync(id);

        if(existingDriver is null)
           return NotFound();

        return Ok(existingDriver);

     }
     [HttpGet]
    public async Task<IActionResult> Get()
    {  
         var allDriver = await _driverService.GetAsync();

         if(allDriver.Any())
             return Ok(allDriver);
         
         return NotFound();
        
    }

    [HttpPost]
    public async Task<IActionResult> Post(Driver driver)
    {
         await _driverService.CreateAsync(driver);
         return CreatedAtAction(nameof(Get), new {id = driver.Id}, driver);

    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Driver driver )
    {
      var existingDriver = await _driverService.GetAsync(id);

      if(existingDriver is null)
         return BadRequest();
     
      driver.Id =  existingDriver.Id;

      await _driverService.UpdateAsync(driver);
      return NoContent();
    }


    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
         var existingDriver = await _driverService.GetAsync(id);

      if(existingDriver is null)
         return BadRequest();
     


      await  _driverService.RemoveAsync(id);
      return NotFound();
    }

 }