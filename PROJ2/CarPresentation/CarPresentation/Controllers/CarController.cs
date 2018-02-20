using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web.Http;
using CarPresentation.Models;
using CarPresentation.Repository;

namespace CarPresentation.Controllers
{
    public class CarController : ApiController
    {
        private readonly ICarRepository _carRepository;

        public CarController()
        {
            _carRepository = new CarRepository();
        }

        public IHttpActionResult GetCar(string model, string lang)
        {
            CarForm car;
            try
            {
                car = _carRepository.FindCarDetails(model, lang);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return NotFound();
            }

            return Ok(car);
        }
    }
}