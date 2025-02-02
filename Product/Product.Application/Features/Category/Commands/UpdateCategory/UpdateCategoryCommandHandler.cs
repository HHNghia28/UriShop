using MediatR;
using Product.Application.Exceptions;
using Product.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler(ICategoryRepository categoryRepository) : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException("Category not found");

            category.LastModifiedBy = request.LastModifiedBy;
            category.Name = request.Name;

            await _categoryRepository.UpdateAsync(category);
            await _categoryRepository.SaveAsync();
        }
    }
}
