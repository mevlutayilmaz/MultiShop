namespace MultiShop.Order.Application.Features.Queries.Orderings.GetOrderingById
{
    public class GetOrderingByIdQueryResponse
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Completed { get; set; }
    }
}