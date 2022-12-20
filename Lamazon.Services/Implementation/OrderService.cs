using AutoMapper;
using Lamazon.DataAccess.Abstraction;
using Lamazon.DomainModels.Entities;
using Lamazon.Services.Abstraction;
using Lamazon.ViewModels.Models;

namespace Lamazon.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public OrderService(IRepository<Order> orderRepository, IMapper mapper, IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public void CreateOrder(OrderViewModel orderViewModel)
        {
            var order = _mapper.Map<Order>(orderViewModel);
            _orderRepository.Add(order);
        }

        public void DeleteOrderById(int id)
        {
            _orderRepository.DeleteById(id);
        }

        public List<OrderViewModel> GetAllOrders()
        {
            var orders = _orderRepository.GetAll();
            return _mapper.Map<List<OrderViewModel>>(orders);
        }

        public OrderViewModel GetOrderById(int id)
        {
            var order = _orderRepository.GetById(id);
            return _mapper.Map<OrderViewModel>(order);
        }

        public List<OrderViewModel> GetAllOrdersByUserId(int id)
        {
            var orders = _orderRepository.GetAll().Where(user => user.Id == id);

            return _mapper.Map<List<OrderViewModel>>(orders);
        }

        public void UpdateOrder(OrderViewModel orderViewModel)
        {
            var order = _mapper.Map<Order>(orderViewModel);
            _orderRepository.Update(order);
        }
    }
}
