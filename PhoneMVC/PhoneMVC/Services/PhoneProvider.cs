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

        public PhoneProvider(ILogger<PhoneProvider> logger)
        {
            _logger = logger;
        }

        public async Task<string> CreateAsync(string brand, string model, int price)
        {
            _logger.LogInformation($"Started {nameof(CreateAsync)}");
            return await Task.Run(() =>
            {
                var id = Guid.NewGuid().ToString();
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

        public async Task<bool> UpdateAsync(string id, string brand, string model, int price)
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

        public async Task<bool> DeleteAsync(string id)
        {
            _logger.LogInformation($"Started {nameof(DeleteAsync)}");
            if (string.IsNullOrEmpty(id))
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

        public async Task<Phone> GetByIdAsync(string id)
        {
            _logger.LogInformation($"Started {nameof(GetByIdAsync)}");
            return await Task.Run(() =>
            {
                return _entities.FirstOrDefault(f => f.Id == id);
            });
        }
    }
}
