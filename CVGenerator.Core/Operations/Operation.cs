using System.Threading.Tasks;

namespace CVGenerator.Core.Operations
{
    public abstract class Operation<TRequest, TModel> : IOperation<TRequest>
    {
        protected Operation(IGeneratorRepository repository)
        {
            _repository = repository;
        }

        protected IGeneratorRepository _repository { get; }

        public sealed class Context
        {
            public TRequest Request { get; }
            public TModel Model { get; }

            public Context(TRequest request, TModel model)
            {
                Request = request;
                Model = model;
            }
        }

        protected abstract Task<TModel> Materialize(TRequest request);

        protected abstract Task Validate(Context context);

        protected abstract Task Apply(Context context);

        /// <summary>
        /// Выполнение запроса
        /// </summary>
        /// <param name="request">Запроc для выполнения операции</param>
        public virtual async Task Execute(TRequest request)
        {
            TModel model = await Materialize(request);

            var context = new Context(request, model);

            await Validate(context);
            await Apply(context);
        }
    }

    public abstract class Operation<TRequest, TResponse, TModel> : IOperation<TRequest, TResponse>
    {
        protected Operation(IGeneratorRepository repository)
        {
            _repository = repository;
        }

        protected IGeneratorRepository _repository { get; }

        public sealed class Context
        {
            public TRequest Request { get; }
            public TModel Model { get; }

            public Context(TRequest request, TModel model)
            {
                Request = request;
                Model = model;
            }
        }

        protected abstract Task<TModel> Materialize(TRequest request);

        protected abstract Task Validate(Context context);

        protected abstract Task<TResponse> Apply(Context context);

        /// <summary>
        /// Выполнение запроса
        /// </summary>
        /// <param name="request">Запроc для выполнения операции</param>
        public virtual async Task<TResponse> Execute(TRequest request)
        {
            TModel model = await Materialize(request);

            var context = new Context(request, model);

            await Validate(context);

            TResponse response = await Apply(context);

            return response;
        }
    }
}
