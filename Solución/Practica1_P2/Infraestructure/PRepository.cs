using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using QueryApi.Domain;
using System.Threading.Tasks;

namespace QueryApi.Repositories
{
    public class PRepository
    {
        List<Per> _prsn;

        public PRepository()
        {
            var fileName = "dummy.data.queries.json";
            if(File.Exists(fileName))
            {
                var json = File.ReadAllText(fileName);
                _prsn = JsonSerializer.Deserialize<IEnumerable<Per>>(json).ToList();
            }
        }
        // Lista de las consultas



        // retornar todos los datos
        public IEnumerable<Per> GetAll()
        {
            var query = _prsn.Select(Per => Per);
            return query;
        }

        // retornar campos especificos
        public IEnumerable<Object> GetFields()
        {
            var query = _prsn.Select(Per => new {
                NombreCompleto = $"{Per.FirstName} {Per.LastName}",
                AnioNacimiento = DateTime.Now.AddYears(Per.Age * -1),
                Correo = Per.Email
            });

            return query;
        }
        // retornar elementos que sean iguales
        public IEnumerable<Per> GetById()
        {
            var generador = new Random(DateTime.Now.Millisecond);
            var id = generador.Next(1000);
            var query = _prsn.Where(Per => Per.Id == id);
            return query;
        }

        public IEnumerable<Per> GetByGender()
        {
            var gender = 'M';
            var query = _prsn.Where(Per => Per.Gender == gender);
            return query;
        }

        public IEnumerable<Per> GetByGenderAndAge()
        {
            var gender = 'M';
            var age = 33;
            var query = _prsn.Where(Per => Per.Gender == gender && Per.Age == age);
            return query;
        }
        // Retornar elementos que sean diferentes
        public IEnumerable<Per> GetDiferences()
        {
            var job = "Civil Engineer";
            var query = _prsn.Where(Per => Per.Job != job);
            return query;
        }
        public IEnumerable<string> GetDistinct()
        {            
            var query = _prsn.Select(Per => Per.Job).Distinct();
            return query;
        }
        // retornar valores que contengan
        public IEnumerable<Per> GetContains()
        {            
            var query = _prsn.Where(Per => Per.FirstName.Contains("ar"));
            return query;
        }
        public IEnumerable<Per> GetByAges()
        {
            var ages = new List<int>{15,25,35,45,55,65};
            var query = _prsn.Where(Per => ages.Contains(Per.Age));
            return query;
        }
        // retornar valores entre un rango
        public IEnumerable<Per> GetByRangeAge()
        {
            var minAge = 30;
            var maxAge = 40;
            var query = _prsn.Where(Per => Per.Age >= minAge && Per.Age <= maxAge);
            return query;
        }
        // retornar elementos ordenados
        public IEnumerable<Per> GetPersonsOrdered()
        {
            var job = "Payment Adjustment Coordinator";
            var query = _prsn.Where(Per => Per.Job == job).OrderBy(Per => Per.LastName);
            return query;
        }

        public IEnumerable<Per> GetPersonsOrderedDescending()
        {
            var job = "Payment Adjustment Coordinator";
            var query = _prsn.Where(Per => Per.Job == job).OrderByDescending(Per => Per.LastName);
            return query;
        }
        // retorno cantidad de elementos
        public int CountPerson()
        {
            var gender = 'F';
            var query = _prsn.Count(Per => Per.Gender == gender);
            return query;
        }
        // Evalua si un elemento existe
        public bool ExistPerson()
        {
            var lastName = "Tuffell";
            var query = _prsn.Exists(Per => Per.LastName == lastName);
            return query;
        }
        // retornar solo un elemento
        public Per GetPerson()
        {
            var id = 340;
            var query = _prsn.FirstOrDefault(Per => Per.Id == id);
            return query;
        }
        // retornar solamente unos elementos
        public IEnumerable<Per> TakePerson()
        {
            var job = "Geological Engineer";
            var take = 3;
            var query = _prsn.Where(Per => Per.Job == job).Take(take);
            return query;
        }
        public IEnumerable<Per> TakeLastPerson()
        {
            var job = "Geological Engineer";
            var take = 3;
            var query = _prsn.Where(person => person.Job == job).TakeLast(take);
            return query;
        }
        // retornar elementos saltando posición
        public IEnumerable<Per> SkipPerson()
        {
            var job = "Professor";
            var skip = 4;
            var query = _prsn.Where(Per => Per.Job == job).Skip(skip);
            return query;
        }
        public IEnumerable<Per> SkipTakePerson()
        {
            var job = "Professor";
            var skip = 4;
            var take = 3;
            var query = _prsn.Where(Per => Per.Job == job).Skip(skip).Take(take);
            return query;
        }
    }
}