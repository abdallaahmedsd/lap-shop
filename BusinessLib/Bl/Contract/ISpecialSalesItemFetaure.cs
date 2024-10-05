namespace BusinessLib.Bl.Contract
{
	public interface ISpecialSalesItemFetaure<TbSalesInvoiceItem>
	{
		bool Save(List<TbSalesInvoiceItem> entity1,int entityId);
	}
}