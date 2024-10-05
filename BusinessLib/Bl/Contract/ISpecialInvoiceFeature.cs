namespace BusinessLib.Bl.Contract
{
	public interface ISpecialInvoiceFeature
	{
		bool Save(List <TbSalesInvoiceItem> entity1, TbSalesInvoice entity2,bool bolean);
	}
}