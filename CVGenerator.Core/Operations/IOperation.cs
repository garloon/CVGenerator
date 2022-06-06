using System.Threading.Tasks;

namespace CVGenerator.Core.Operations
{
	/// <summary>
	/// Операция
	/// </summary>
	/// <typeparam name="TRequest">Тип запроса</typeparam>
	public interface IOperation<in TRequest>
	{
		/// <summary>
		/// Выполнить операцию
		/// </summary>
		/// <param name="request">Запрос</param>
		Task Execute(TRequest request);
	}

	/// <summary>
	/// Операция
	/// </summary>
	/// <typeparam name="TRequest">Тип запроса</typeparam>
	/// <typeparam name="TResponse">Тип ответа</typeparam>
	public interface IOperation<in TRequest, TResponse>
	{
		/// <summary>
		/// Выполнить операцию
		/// </summary>
		/// <param name="request">Запрос</param>
		Task<TResponse> Execute(TRequest request);
	}
}