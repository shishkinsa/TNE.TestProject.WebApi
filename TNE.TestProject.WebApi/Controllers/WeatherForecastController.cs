using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TNE.TestProject.WebApi.Repository;

namespace TNE.TestProject.WebApi.Controllers
{
    /// <summary>
    /// Тестовый контроллер для выполнения
    /// тестовых заданий по работе с Postman
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly RepositoryCity _repository;

        private readonly ILogger<WeatherForecastController> _logger;    

        public WeatherForecastController(ILogger<WeatherForecastController> logger, RepositoryCity repository)
        {
            _logger = logger;
            _repository = repository;
        }

        /// <summary>
        /// Получить данные по температуре
        /// </summary>
        /// <returns> Массив дат и температуры</returns>
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(0, _repository.Citys.Count).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = _repository.Citys[index]
                })
                .ToArray();
        }
        
        /// <summary>
        /// Добавить город для получения диапазона дат
        /// </summary>
        /// <returns> Новый идекс города </returns>
        [HttpPost]
        public int Post(string nameCity)
        {
            _repository.AddCity(nameCity);
            return _repository.Citys.Count;
        }
    }
}