using Microsoft.AspNetCore.Mvc;
using Service1.APIs.Common;
using Service1.Infrastructure.Models;

namespace Service1.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class MeFindMany : FindManyInput<Me, MeWhereInput> { }
