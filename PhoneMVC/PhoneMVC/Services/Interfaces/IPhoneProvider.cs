using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhoneMVC.Models;

namespace PhoneMVC.Services.Interfaces
{
    public interface IPhoneProvider
    {
        Task<string> CreateAsync(string brand, string model, int price);

        Task<bool> UpdateAsync(string id, string brand, string model, int price);

        Task<bool> DeleteAsync(string id);

        Task<Phone> GetByIdAsync(string id);
    }
}
