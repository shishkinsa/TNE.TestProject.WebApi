using System.Collections.Generic;

namespace TNE.TestProject.WebApi.Repository
{   
    /// <summary>
    /// Репозитой городов для получения
    /// по ним температуры
    /// </summary>
    public class RepositoryCity
    {
        private List<string> _citys = new  List<string>()
        {
            "Москва", "Владимир", "Ковров", "Псков", "Минск"
        };

        public List<string> Citys => _citys;

        public void AddCity(string name) => _citys.Add(name);
    }
}