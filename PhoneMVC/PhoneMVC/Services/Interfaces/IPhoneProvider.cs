using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhoneMVC.Models;

namespace PhoneMVC.Services.Interfaces
{
    public interface IPhoneProvider
    {
        Task<int> CreateAsync(string brand, string model, int price);

        Task<bool> UpdateAsync(int? id, string brand, string model, int price);

        Task<bool> DeleteAsync(int? id);

        Task<Phone> GetByIdAsync(int? id);
    }
}
