﻿using Shows4All.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shows4All.Models
{
    public class ClienteSeriesModel
    {
        public int Id { get; set; }

        [ForeignKey("ClientID")]
        public ClienteModel ClientModel { get; set; }

        [ForeignKey("SerieID")]
        public SerieModel SerieModel { get; set; }

        public Double PricePaid { get; set; }

        private readonly ApplicationDbContext _context;

        public ClienteSeriesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Method to set properties
        public void Initialize(int clienteID, int serieID, double pricePaid)
        {
            // Retrieve ClienteModel from the database based on clienteID
            this.ClientModel = _context.ClienteDB.FirstOrDefault(c => c.Id == clienteID);

            // Retrieve SerieModel from the database based on serieID
            this.SerieModel = _context.SerieDB.FirstOrDefault(s => s.Id == serieID);

            this.PricePaid = pricePaid;
        }
    }
}
