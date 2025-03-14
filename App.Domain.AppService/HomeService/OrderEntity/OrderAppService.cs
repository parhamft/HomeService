using HomeService.Domain.Core.HomeService.Account.AppService;
using HomeService.Domain.Core.HomeService.BaseData.Service;
using HomeService.Domain.Core.HomeService.ImageEntity;
using HomeService.Domain.Core.HomeService.OfferEntity.DTO;
using HomeService.Domain.Core.HomeService.OrderEntity.AppServices;
using HomeService.Domain.Core.HomeService.OrderEntity.Data;
using HomeService.Domain.Core.HomeService.OrderEntity.DTO;
using HomeService.Domain.Core.HomeService.OrderEntity.Enums;
using HomeService.Domain.Core.HomeService.OrderEntity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.HomeService.OrderEntity
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IOrderService _orderService;
        private readonly IBaseDataService _baseDataService;

        public OrderAppService(IOrderService orderService, IBaseDataService baseDataService)
        {
            _orderService = orderService;
            _baseDataService = baseDataService;
        }
        public async Task<bool> Add(AddOrderDTO addOrderDTO, CancellationToken cancellationToken)
        {
            if(addOrderDTO.ImageFiles!=null)
            {
                foreach(var i in addOrderDTO.ImageFiles)
                {
                    var Image = new Image { ImagePath= await _baseDataService.UploadImage(i, "Orders", cancellationToken) };
                    addOrderDTO.Images.Add(Image);
                }
            }
            
            var result = await _orderService.Add(addOrderDTO, cancellationToken);
            return result;
        }
        public async Task<List<GetOrderDTO>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _orderService.GetAll(cancellationToken);
            return result;
        }
        public async Task<List<GetOrderDTO>> GetAllAccepted(int ExpertId, CancellationToken cancellationToken)
        {
            return await _orderService.GetAllAccepted(ExpertId, cancellationToken);
        }
        public async Task<List<GetOrderDTO>> GetOrdersForExpert(List<int> Services, int? CityId, CancellationToken cancellationToken)
        {
            return await _orderService.GetOrdersForExpert(Services, CityId, cancellationToken);
        }
        public async Task<List<GetOrderDTO>> GetAllOfUsers(int id, CancellationToken cancellationToken)
        {
            var result = await _orderService.GetAllOfUsers(id, cancellationToken);
            return result;
        }
        public async Task<GetOrderDTO> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _orderService.GetById(id, cancellationToken);
            return result;
        }
        public async Task<bool> Update(GetOfferDTO getOfferDTO, CancellationToken cancellationToken)
        {
            var order = new GetOrderDTO
            {
                Id= getOfferDTO.OrderId,
                Expert = getOfferDTO.Expert,
                Status = StatusEnum.ExpertAccepted
                
            };
            var result = await _orderService.Update(order , cancellationToken);
            
            return result;

        }
        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _orderService.Delete(id, cancellationToken);
            return result;
        }
        public async Task<bool> ChangeStatus(int id, int status, CancellationToken cancellationToken)
        {
            var result= await _orderService.CheckIfOffersExist(id, cancellationToken);
            if (result==false)
            {
                throw new Exception("پیشتهادی وجود ندارد");
            }
            if (result == true && status == 1)
            {
                throw new Exception("پیشتهادی وجود دارد");
            }
            var expert = await _orderService.CheckExpert(id, cancellationToken);
            if (expert == false && status >2) 
            {
                throw new Exception("متخصص انتخاب نشده");
            }
            if (expert == true && status <= 2)
            {
                throw new Exception("متخصص انتخاب شده");
            }

            var order = await _orderService.GetById(id, cancellationToken);
            if (expert == true && status <= 5)
            {
                order.Expert = null;
            }
            order.Status = (StatusEnum)status;
            return await _orderService.Update(order,cancellationToken);
             
        }
    }
}
