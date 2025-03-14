using HomeService.Domain.Core.HomeService.BaseData.Service;
using HomeService.Domain.Core.HomeService.CommentEntity.AppServices;
using HomeService.Domain.Core.HomeService.ExpertEntity.AppServices;
using HomeService.Domain.Core.HomeService.ExpertEntity.DTO;
using HomeService.Domain.Core.HomeService.ExpertEntity.Entities;
using HomeService.Domain.Core.HomeService.ExpertEntity.Services;
using HomeService.Domain.Core.HomeService.OrderEntity.AppServices;
using HomeService.Domain.Core.HomeService.OrderEntity.DTO;
using HomeService.Domain.Core.HomeService.OrderEntity.Enums;
using HomeService.Domain.Core.HomeService.OrderEntity.Services;
using HomeService.Domain.Core.HomeService.ServiceEntity.AppServices;


namespace App.Domain.AppServices.HomeService.ExpertEntity
{
    public class ExpertAppService : IExpertAppService
    {
        private readonly IExpertService _expertService;
        private readonly IOrderAppService _orderAppService;
        private readonly IOrderService _order;
        private readonly IBaseDataService _baseDataService;
        private readonly IcommentAppService _icommentAppService;

        public ExpertAppService(IExpertService expertService, IOrderAppService orderAppService, IOrderService order,IBaseDataService baseDataService)
        {
            _expertService = expertService;
            _orderAppService = orderAppService;
            _order = order;
            _baseDataService = baseDataService;

        }
        public async Task<UpdateExpertDTO> GetUpdate(int id, CancellationToken cancellationToken)
        {
            return await _expertService.GetUpdate(id, cancellationToken);
        }
        public async Task<List<GetExpertDTO>> GetAll(CancellationToken cancellationToken)
        {
            return await _expertService.GetAll(cancellationToken);
        }
        public async Task<GetExpertDTO> GetById(int Id, CancellationToken cancellationToken)
        {
            return await _expertService.GetById(Id, cancellationToken);
        }
        public async Task<bool> Create(Expert expert, CancellationToken cancellationToken)
        {
            return await _expertService.Create(expert, cancellationToken);
        }
        public async Task<bool> Update(UpdateExpertDTO expert, CancellationToken cancellationToken)
        {
            if (expert.ProfileImgFile != null)
            {
                expert.ImagePath = await _baseDataService.UploadImage(expert.ProfileImgFile!, "Users", cancellationToken);
            }
            return await _expertService.Update(expert, cancellationToken);
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellationToken)
        {
            return await _expertService.Delete(Id, cancellationToken);
        }
        public async Task<bool> FinishJob(int orderId, CancellationToken cancellationToken)
        {
            var order = await _order.GetById(orderId, cancellationToken);
            order.Status = StatusEnum.WaitingForPayment;
            return await _order.Update(order, cancellationToken);
        }
        public async Task<List<GetOrderDTO>> GetOrdersForExpert(GetExpertDTO getExpertDTO , CancellationToken cancellationToken)
        {
            List<int> serviceIds = new List<int>();
            foreach(var x in getExpertDTO.Services)
            {
               serviceIds.Add(x.Id);
            }
            var result= await  _orderAppService.GetOrdersForExpert(serviceIds,getExpertDTO.CityId, cancellationToken);
            return result;
        }
    }
}
