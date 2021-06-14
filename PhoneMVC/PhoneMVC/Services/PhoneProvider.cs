using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PhoneMVC.Models;
using PhoneMVC.Services.Interfaces;

namespace PhoneMVC.Services
{
    public class PhoneProvider : IPhoneProvider
    {
        private readonly ILogger<PhoneProvider> _logger;
        private readonly List<Phone> _entities = new List<Phone>();
        private int _count;

        public PhoneProvider(ILogger<PhoneProvider> logger)
        {
            _logger = logger;
            _count = 1;
        }

        public async Task<int> CreateAsync(string brand, string model, int price)
        {
            _logger.LogInformation($"Started {nameof(CreateAsync)}");
            return await Task.Run(() =>
            {
                var id = _count++;
                _entities.Add(new Phone()
                {
                    Id = id,
                    Brand = brand,
                    Model = model,
                    Price = price
                });

                return id;
            });
        }

        public async Task<bool> UpdateAsync(int? id, string brand, string model, int price)
        {
            _logger.LogInformation($"Started {nameof(UpdateAsync)}");

            return await Task.Run(() =>
            {
                var item = _entities.FirstOrDefault(f => f.Id == id);
                if (item == null)
                {
                    return false;
                }

                item.Brand = brand;
                item.Model = model;
                item.Price = price;

                return true;
            });
        }

        public async Task<bool> DeleteAsync(int? id)
        {
            _logger.LogInformation($"Started {nameof(DeleteAsync)}");
            if (id.HasValue)
            {
                return false;
            }

            return await Task.Run(() =>
            {
                var item = _entities.FirstOrDefault(f => f.Id == id);
                if (item == null)
                {
                    return false;
                }

                return _entities.Remove(item);
            });
        }

        public async Task<Phone> GetByIdAsync(int? id)
        {
            _logger.LogInformation($"Started {nameof(GetByIdAsync)}");
            return await Task.Run(() =>
            {
                return _entities.FirstOrDefault(f => f.Id == id);
            });
        }
    }
}
