using Entidade;
using Entidade.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Cadastro
{
    public class NegIndicado
    {
        private readonly IMongoCollection<Indicador> _settings;

        public NegIndicado(IIndicadoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _settings = database.GetCollection<Indicador>(settings.BooksCollectionName);
        }
        public Indicador Create(Indicador indicado)
        {
            _settings.InsertOne(indicado);
            return indicado;
        }
    }
}
