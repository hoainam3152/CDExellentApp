using CDExellentAPI.DTO.Requests;
using CDExellentAPI.DTO.Responses;
using CDExellentAPI.Entities;
using CDExellentAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CDExellentAPI.Services
{
    public class DistributorService :  IDistributorRepository
    {
        private readonly ManagementDbContext context;

        public DistributorService(ManagementDbContext context)
        {
            this.context = context;
        }

        public DistributorResponse? Create(DistributorRequest request)
        {
            try
            {
                context.Distributors.Add(new Distributor()
                {
                    Name = request.Name,
                    Email = request.Email,
                    Address = request.Address,
                    PhoneNumber = request.PhoneNumber,
                    SalesManagementId = request.SalesManagementId,
                    SalesId = request.SalesId,
                    Status = request.Status,
                    AreaId = request.AreaId
                });
                context.SaveChanges();
                //var us = context.Distributors.OrderBy(ett => ett.ID).Last();
                return new DistributorResponse(/*us*/);
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public DistributorResponse? Delete(int id)
        {
            try
            {
                var dtbt = context.Distributors.FirstOrDefault(ett => ett.ID == id);
                if (dtbt != null)   //Data exist
                {
                    context.Distributors.Remove(dtbt);
                    context.SaveChanges();
                    return new DistributorResponse(dtbt);
                }
                return null;
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public IEnumerable<DistributorResponse> GetAll()
        {
            return context.Distributors
                .Select(ett => new DistributorResponse()
                {
                    ID = ett.ID,
                    Name = ett.Name,
                    Email = ett.Email,
                    Address = ett.Address,
                    PhoneNumber = ett.PhoneNumber,
                    SalesManagementId = ett.SalesManagementId,
                    SalesId = ett.SalesId,
                    Status = ett.Status,
                    AreaId = ett.AreaId
                })
                .ToList();
        }

        public DistributorResponse? GetById(int id)
        {
            var dtbt = context.Distributors.FirstOrDefault(ett => ett.ID == id);
            if (dtbt != null)
            {
                return new DistributorResponse(dtbt);
            }
            return null;
        }

        public DistributorResponse? Update(int id, DistributorRequest request)
        {
            try
            {
                var dtbt = context.Distributors.FirstOrDefault(ett => ett.ID == id);
                if (dtbt != null)   //Data exist
                {
                    dtbt.Name = request.Name;
                    dtbt.Email = request.Email;
                    dtbt.Address = request.Address;
                    dtbt.PhoneNumber = request.PhoneNumber;
                    dtbt.SalesManagementId = request.SalesManagementId;
                    dtbt.SalesId = request.SalesId;
                    dtbt.Status = request.Status;
                    dtbt.AreaId = request.AreaId;
                    context.SaveChanges();
                    return new DistributorResponse(dtbt);
                }
                return null;
            }
            catch
            {
                throw new DbUpdateException();
            }
        }
    }
}
