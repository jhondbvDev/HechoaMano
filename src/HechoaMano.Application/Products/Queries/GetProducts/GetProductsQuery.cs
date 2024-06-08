﻿using HechoaMano.Application.Products.Common;
using MediatR;

namespace HechoaMano.Application.Products.Queries.GetProducts;

public record GetProductsQuery() : IRequest<List<ProductResult>>;
