using Microsoft.AspNetCore.Mvc;
using LisaApi.Data;
using LisaApi.Models;
using LisaApi.Services.Dto;

namespace LisaApi.Controllers;

[Route("api/property")]
[ApiController]
// [Authorize]
public class PropertyController : ControllerBase
{
    private readonly AppDbContext _context;

    public PropertyController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetProperties()
    {
        var properties = _context.Properties.ToList();
        return Ok(properties);
    }

    [HttpGet("{id}")]
    public IActionResult GetProperty(int id)
    {
        var property = _context.Properties.FirstOrDefault(p => p.PropertyId == id);
        if (property == null)
        {
            return NotFound();
        }
        return Ok(property);
    }

    // [HttpPost]
    // public IActionResult CreateProperty(Property property)
    // {
    //     _context.Properties.Add(property);
    //     _context.SaveChanges();
    //     return CreatedAtAction(nameof(GetProperty), new { id = property.PropertyId }, property);
    // }


    // [HttpPost]
    // public IActionResult CreateProperty([FromBody] PropertyDto propertyDTO)
    // {
    //     var property = new Property
    //     {
    //         Name = propertyDTO.Name,
    //         Price = propertyDTO.Price,
    //         MeterNumber = propertyDTO.MeterNumber,
    //         MeterImg = propertyDTO.MeterImg,
    //         Address = propertyDTO.Address,
    //         Type = propertyDTO.Type,
    //         RentalStatus = propertyDTO.RentalStatus,
    //         UpdatedAt = DateTime.Now
    //     };

    //     _context.Properties.Add(property);
    //     _context.SaveChanges();
    //     return CreatedAtAction(nameof(GetProperty), new { id = property.PropertyId }, property);
    // }


    [HttpPost]
    public IActionResult CreateProperty([FromForm] PropertyDto propertyDTO)
    {
        var property = new Property
        {
            Name = propertyDTO.Name,
            Price = propertyDTO.Price,
            MeterNumber = propertyDTO.MeterNumber,
            Address = propertyDTO.Address,
            Type = propertyDTO.Type,
            RentalStatus = propertyDTO.RentalStatus,
        };

        if (propertyDTO.MeterImg != null)
        {
            using (var ms = new MemoryStream())
            {
                propertyDTO.MeterImg.CopyTo(ms);
                var fileBytes = ms.ToArray();
                property.MeterImg = Convert.ToBase64String(fileBytes);
            }
        }

        _context.Properties.Add(property);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetProperty), new { id = property.PropertyId }, property);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProperty(int id, Property property)
    {
        var existingProperty = _context.Properties.FirstOrDefault(p => p.PropertyId == id);
        if (existingProperty == null)
        {
            return NotFound();
        }

        existingProperty.Name = property.Name;
        existingProperty.Price = property.Price;
        existingProperty.MeterNumber = property.MeterNumber;
        existingProperty.MeterImg = property.MeterImg;
        existingProperty.Address = property.Address;
        existingProperty.Type = property.Type;
        existingProperty.RentalStatus = property.RentalStatus;
        existingProperty.UpdatedAt = DateTime.Now;

        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProperty(int id)
    {
        var property = _context.Properties.FirstOrDefault(p => p.PropertyId == id);
        if (property == null)
        {
            return NotFound();
        }

        _context.Properties.Remove(property);
        _context.SaveChanges();
        return NoContent();
    }
}
