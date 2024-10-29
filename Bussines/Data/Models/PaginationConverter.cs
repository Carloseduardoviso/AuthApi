using AutoMapper;

namespace Bussines.Data.Models
{
    public class PaginationConverter<TSource, TDestination> : ITypeConverter<Pagination<TSource>, Pagination<TDestination>>
    {
        private readonly IMapper _mapper;

        public PaginationConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Pagination<TDestination> Convert(Pagination<TSource> source, Pagination<TDestination> destination, ResolutionContext context)
        {
            var mappedItems = _mapper.Map<IEnumerable<TDestination>>(source.Items);
            return new Pagination<TDestination>(source.TotalItems, source.CurrentPage, source.TotalPages, mappedItems);
        }
    }
}
