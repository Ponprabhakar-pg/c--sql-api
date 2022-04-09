using AutoMapper;
using ShoppingApiModal;
using ShoppingApiRepository.SqlEntity;


namespace ShoppingApiService
{
    public class Automapping: Profile
    {
        public Automapping()
        {
            CreateMap<SqlEntityProductModal, ProductModal>()
                .ReverseMap();
        }
    }
}
