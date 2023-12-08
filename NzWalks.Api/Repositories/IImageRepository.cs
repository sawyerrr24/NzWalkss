using NzWalks.Api.Models.Domain;

namespace NzWalks.Api.Repositories
{
    public interface IImageRepository
    {
       Task <Image> Upload(Image image);

    }
}
