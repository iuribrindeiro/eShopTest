using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using eShopTest.ApplicationService.OrderAggregate.ViewModels;
using eShopTest.ApplicationService.SeedWork.ViewModel;
using eShopTest.Domain.BasketAggregate;
using eShopTest.Domain.OrderAggregate;

namespace eShopTest.ApplicationService.OrderAggregate
{
    public class OrderApplicationService : IOrderApplicationService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public OrderApplicationService(IOrderRepository orderRepository, IBasketRepository basketRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public OrderViewModel Create(Guid basketId)
        {
            var order = new Order(_basketRepository.Find(basketId));
            _orderRepository.Save(order);
            return _mapper.Map<Order, OrderViewModel>(order);
        }

        public PaginationViewModel<OrderViewModel> GetOrders(int pageSize = 10, int pageIndex = 1)
        {
            return _mapper.Map<PaginationViewModel<OrderViewModel>>(
                _orderRepository.SearchWithPagination(pageSize, pageIndex));
        }

        public OrderViewModel Get(Guid id)
        {
            return _mapper.Map<Order, OrderViewModel>(_orderRepository.Find(id));
        }
    }
}
