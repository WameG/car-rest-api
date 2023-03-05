using car_rest_api.Repositories;
using CarLibary;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace car_rest_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private CarRepository _carRepository;

        public CarsController(CarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        // GET: api/<CarsController>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            List<Car> result = _carRepository.GetAll();

            if(result.Count < 1)
            {
                return NoContent();
            }

            return Ok(result);
        }

        // GET api/<CarsController>/5
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public ActionResult<Car?> Get(int id)
        {
            Car? foundCar = _carRepository.GetById(id);

            if(foundCar == null)
            {
                return NotFound();
            }

            return Ok(foundCar);
        }

        // POST api/<CarsController>
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public ActionResult<Car> Post([FromBody] Car newCar)
        {
            try
            {
                Car createdCar = _carRepository.Add(newCar);
                return Created($"api/cars/{createdCar.Id}", createdCar);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CarsController>/5
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPut("{id}")]
        public ActionResult<Car> Put(int id, [FromBody] Car updateCar)
        {
            try
            {
                Car? updatedCar = _carRepository.Update(id, updateCar);

                if (updatedCar == null)
                {
                    return NotFound();
                }

                return Ok(updatedCar);
            }
            catch (ArgumentOutOfRangeException ex)
            {

                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CarsController>/5
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Car> Delete(int id)
        {
            Car? deletedCar = _carRepository.Delete(id);

            if(deletedCar == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
