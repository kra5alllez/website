using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PhoneMVC.Models;
using PhoneMVC.Services.Interfaces;

namespace PhoneMVC.Services
{
    public class ManageService : IManageService
    {
        private readonly ILogger<ManageService> _logger;
        private readonly IPhoneProvider _phoneProvider;

        public ManageService(ILogger<ManageService> logger, IPhoneProvider phoneProvider)
        {
            _logger = logger;
            _phoneProvider = phoneProvider;
        }

        public async Task<string> CreateAsync(string brand, string model, int price)
        {
            _logger.LogInformation($"Started {nameof(CreateAsync)}");
            return await _phoneProvider.CreateAsync(brand, model, price);
        }

        public async Task<bool> UpdateAsync(string id, string brand, string model, int price)
        {
            _logger.LogInformation($"Started {nameof(UpdateAsync)}");
            return await _phoneProvider.UpdateAsync(id, brand, model, price);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            _logger.LogInformation($"Started {nameof(DeleteAsync)}");
            return await _phoneProvider.DeleteAsync(id);
        }

        public async Task<Phone> GetByIdAsync(string id)
        {
            _logger.LogInformation($"Started {nameof(GetByIdAsync)}");
            return await _phoneProvider.GetByIdAsync(id);
        }
    }
}
