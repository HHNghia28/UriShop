using MediatR;
using Product.Application.Exceptions;
using Product.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler(IProductRepository productRepository) : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException("Product not found");

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Discount = request.Discount;
            product.Stock = request.Stock;
            product.Photo = request.Photo;
            product.CategoryId = request.CategoryId;
            product.LastModifiedBy = request.LastModifiedBy;

            await _productRepository.UpdateAsync(product);
            await _productRepository.SaveAsync();
        }
    }
}
