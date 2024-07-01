using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagementApp.Components.Data
{
    public class EquipmentDbService
    {
        private string _dbName = "equipment_management_local_db.db3";
        private readonly SQLiteAsyncConnection _connection;

        public EquipmentDbService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, _dbName));
            _connection.CreateTableAsync<Equipment>();
        }

        public async Task<List<Equipment>> GetEquipment()
        {
            return await _connection.Table<Equipment>().ToListAsync();
        }

        public async Task CreateEquipment(Equipment equipment)
        {
            await _connection.InsertAsync(equipment);
        }

        public async Task UpdateEquipment(Equipment equipment)
        {
            await _connection.UpdateAsync(equipment);
        }

        public async Task DeleteEquipment(Equipment equipment)
        {
            await _connection.DeleteAsync(equipment);
        }

    }
}
