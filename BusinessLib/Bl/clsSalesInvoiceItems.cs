
namespace BusinessLib.Bl
{
public class clsSalesInvoiceItems : IBusinessInterface<TbSalesInvoiceItem>,ISpecialSalesItemFetaure<TbSalesInvoiceItem>
{
	private readonly AppDbContext _appDbContext;
	public clsSalesInvoiceItems(AppDbContext appDbContextSerivce)
	{
		_appDbContext = appDbContextSerivce;
	}
	public IEnumerable<TbSalesInvoiceItem> GetAll()
	{
		try
		{


			return _appDbContext.TbSalesInvoiceItems.AsNoTracking().OrderBy(x => x.Qty);
		}
		catch (Exception ex)
		{

			return new List<TbSalesInvoiceItem>();
		}

	}

		/// <summary>
		/// returns item in sales invoice details
		/// </summary>
		/// <param name="elementId">item id </param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
	public TbSalesInvoiceItem GetById(int elementId)
	{

		try
		{

			return _appDbContext.TbSalesInvoiceItems.SingleOrDefault(x => x.ItemId == elementId);
				//Do you want to include items of invoice ? 
		}

		catch (Exception ex)
		{
			throw new Exception(ex.Message);

		}

	}
	public bool Save(List<TbSalesInvoiceItem> lstSalesInvoiceItems,int invoiceId)
	{

		try
		{
				List<TbSalesInvoiceItem> lstItemsInvoiceInDatabase =
				_appDbContext.TbSalesInvoiceItems
				.Where(x => x.InvoiceId == invoiceId)
				.ToList();

				foreach (var item in lstSalesInvoiceItems)
				{

					item.InvoiceId = invoiceId;
					//is in both database ,and lstofItems (edit)
					if (lstItemsInvoiceInDatabase.Where(x => x.ItemId == item.ItemId).Any())
					{
						_appDbContext.Entry(item).State = EntityState.Modified;

					}
					//is not in database and in list I have (add)
					else if (!lstItemsInvoiceInDatabase.Where(x => x.ItemId == item.ItemId).Any())
					{
						_appDbContext.TbSalesInvoiceItems.Add(item);
					}

				}
				//to remove ...//
				//you can make it in an easy way if you send deleted item with list and just mark it as deleted..
				foreach(var itemIndatabase in lstItemsInvoiceInDatabase)
				{

					if (!lstSalesInvoiceItems.Where(x => x.ItemId == itemIndatabase.ItemId).Any())
					{
						_appDbContext.Remove(itemIndatabase);
					}
				}
				//in one 
				return true;
		}
		catch (Exception ex) { return false; }

	}
	public bool Delete(int elementId)
	{
		try
		{

			TbSalesInvoiceItem elementToDelete = GetById(elementId);
			_appDbContext.TbSalesInvoiceItems.Remove(elementToDelete);
			if (_appDbContext.SaveChanges() > 0)
				return true;

		}
		catch (Exception ex)
		{
			return false;
		}
		return false;

	}

		public bool Save(TbSalesInvoiceItem element)
		{
			throw new NotImplementedException();
		}
	}
}