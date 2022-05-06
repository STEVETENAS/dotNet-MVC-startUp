using MininalCategory;
using MininalCategory.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<MinimalContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

async Task<List<Category>> GetAllCategories(MinimalContext context) => await context.Categories.ToListAsync();
async Task<List<Category>> GetCategories(MinimalContext context) => await context.Categories.Where(x => x.DeletedAt == null).ToListAsync();
async Task<List<Category>> GetDeletedCategories(MinimalContext context) => await context.Categories.Where(x => x.DeletedAt != null).ToListAsync();

app.MapGet("/category", async (MinimalContext context) => await context.Categories.Where(x => x.DeletedAt == null).ToListAsync());

app.MapGet("/category/{id}", async (MinimalContext context, Guid id) 
    => await context.Categories.FindAsync(id) is Category category ? Results.Ok(category) : Results.NotFound("Unknown ID"));

app.MapPost("/category", async (MinimalContext context, Category category) =>
{
    await context.Categories.AddAsync(category);
    await context.SaveChangesAsync();
    return Results.Ok(category);
});

app.MapPut("/category/{id}", async (MinimalContext context, Category category, Guid id) =>
{
    var cat = await context.Categories.FindAsync(id);
    if (cat != null) Results.NotFound("Unknown ID");

    cat.Name = category.Name ?? cat.Name;
    cat.DisplayOrder = category.DisplayOrder !=0 ? category.DisplayOrder : cat.DisplayOrder;
    await context.SaveChangesAsync();
    return Results.Ok(category);
});

app.MapDelete("/category/{id}", async (MinimalContext context, Guid id) =>
{
    var category = await context.Categories.FindAsync(id);
    if (category != null) Results.NotFound("Unknown ID");

    Category cat = new(category,DateTime.UtcNow);
    //context.Categories.Remove(category); 
    await context.SaveChangesAsync();
    return Results.Ok(category);
});

app.Run();

