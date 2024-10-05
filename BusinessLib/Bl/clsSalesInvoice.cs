using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BusinessLib.Bl
{
	public class clsSalesInvoice : IBusinessInterface<TbSalesInvoice>,ISpecialInvoiceFeature
	{
		private readonly AppDbContext _appDbContext;
		private readonly ISpecialSalesItemFetaure<TbSalesInvoiceItem> _salesInvoiceItems;
		public clsSalesInvoice(AppDbContext appDbContextSerivce, ISpecialSalesItemFetaure<TbSalesInvoiceItem> salesInvoiceItems)
		{
			_appDbContext = appDbContextSerivce;
			_salesInvoiceItems = salesInvoiceItems;
		}
		public bool Delete(int elementId)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<TbSalesInvoice> GetAll()
		{
			throw new NotImplementedException();
		}

		public TbSalesInvoice GetById(int elementId)
		{
			throw new NotImplementedException();
		}

	
		public bool Save(List<TbSalesInvoiceItem> lstSalesInvoiceItems, TbSalesInvoice invoice, bool isNew)
		{

			using (var transaction = _appDbContext.Database.BeginTransaction())
			{

				try
				{
					if (isNew)
					{
						_appDbContext.Add(invoice);

					}
	
					else
					{
						_appDbContext.Entry(invoice).State = EntityState.Modified;

					}

					_appDbContext.SaveChanges();

					_salesInvoiceItems.Save(lstSalesInvoiceItems, invoice.InvoiceId);
					
					_appDbContext.SaveChanges();

					transaction.Commit();

				}
				catch (Exception ex)
				{
					transaction?.Rollback();
				}
				return true;
			}

		}

		public bool Save(TbSalesInvoice element)
		{
			throw new NotImplementedException();
		}

	}

}

