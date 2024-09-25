using MultiShop.UI.Handlers;
using MultiShop.UI.Services.BasketServices;
using MultiShop.UI.Services.CatalogServices.BrandServices;
using MultiShop.UI.Services.CatalogServices.CategoryServices;
using MultiShop.UI.Services.CatalogServices.FeatureSliderServices;
using MultiShop.UI.Services.CatalogServices.OfferDiscountServices;
using MultiShop.UI.Services.CatalogServices.ProductDetailServices;
using MultiShop.UI.Services.CatalogServices.ProductImageServices;
using MultiShop.UI.Services.CatalogServices.ProductServices;
using MultiShop.UI.Services.CatalogServices.SpecialOfferServices;
using MultiShop.UI.Services.CommentServices;
using MultiShop.UI.Services.Concrete;
using MultiShop.UI.Services.DiscountServices;
using MultiShop.UI.Services.Interfaces;
using MultiShop.UI.Services.MessageServices;
using MultiShop.UI.Services.OrderServices.AddressServices;
using MultiShop.UI.Services.OrderServices.OrderingServices;
using MultiShop.UI.Services.UserIdentityServices;
using MultiShop.UI.Settings;

namespace MultiShop.UI.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static void AddUIServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<ClientSettings>(configuration.GetSection("ClientSettings"));
			services.Configure<ServiceApiSettings>(configuration.GetSection("ServiceApiSettings"));

			services.AddScoped<ResourceOwnerPasswordTokenHandler>();
			services.AddScoped<ClientCredentialTokenHandler>();

			services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();

			var values = configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();

			services.AddHttpClient<IUserService, UserService>(opt =>
			{
				opt.BaseAddress = new Uri(values.IdentityServiceUrl);
			}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<IUserIdentityService, UserIdentityService>(opt =>
            {
                opt.BaseAddress = new Uri(values.IdentityServiceUrl);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<IBasketService, BasketService>(opt =>
            {
                opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Basket.Path}");
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<IDiscountService, DiscountService>(opt =>
            {
                opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Discount.Path}");
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<IAddressService, AddressService>(opt =>
            {
                opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Order.Path}");
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<IOrderingService, OrderingService>(opt =>
            {
                opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Order.Path}");
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<IMessageService, MessageService>(opt =>
            {
                opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Message.Path}");
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<ICategoryService, CategoryService>(opt =>
			{
				opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
			}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

			services.AddHttpClient<IProductService, ProductService>(opt =>
			{
				opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
			}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

			services.AddHttpClient<IBrandService, BrandService>(opt =>
			{
				opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
			}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

			services.AddHttpClient<IFeatureSliderService, FeatureSliderService>(opt =>
			{
				opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
			}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

			services.AddHttpClient<IOfferDiscountService, OfferDiscountService>(opt =>
			{
				opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
			}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

			services.AddHttpClient<IProductDetailService, ProductDetailService>(opt =>
			{
				opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
			}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

			services.AddHttpClient<IProductImageService, ProductImageService>(opt =>
			{
				opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
			}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

			services.AddHttpClient<ISpecialOfferService, SpecialOfferService>(opt =>
			{
				opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
			}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

			services.AddHttpClient<ICommentService, CommentService>(opt =>
			{
				opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Comment.Path}");
			}).AddHttpMessageHandler<ClientCredentialTokenHandler>();
		}
	}

}
