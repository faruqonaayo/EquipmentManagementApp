using Microsoft.AspNetCore.Components;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagementApp.Components.Data
{
    [SQLite.Table("equipment")]
    public class Equipment
    {
        [PrimaryKey]
        [AutoIncrement]
        [SQLite.Column("id")]
        public int Id { get; set; }

        [SQLite.Column("category")]
        public string Category {  get; set; }

        [SQLite.Column("name")]
        public string Name { get; set; }

        [SQLite.Column("description")]
        public string Description { get; set; }

        [SQLite.Column("daily_rental_cost")]
        public string DailyRentalCost { get; set; }
    }
}
