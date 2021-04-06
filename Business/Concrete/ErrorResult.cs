using Core.Utilities.Results;

namespace Business.Concrete
{
    internal class ErrorResult : IResult
    {
        public ErrorResult(string v)
        {
            V = v;
        }

        public string V { get; }
    }
}