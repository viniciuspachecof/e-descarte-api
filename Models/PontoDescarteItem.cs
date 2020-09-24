namespace e_descarte_api.Models
{
    public class PontoDescarteItem
    {
        public PontoDescarteItem() { }        
        public PontoDescarteItem(int id, int quant, int pontodescarteId, PontoDescarte pontodescarte, int itemId, Item item)
        {

            this.id = id;
            this.quant = quant;            
            this.pontodescarteId = pontodescarteId;
            this.pontodescarte = pontodescarte;
            this.itemId = itemId;
            this.item = item;            
        }
        
        public int id { get; set; }
        public int quant { get; set; }
        public int pontodescarteId { get; set; }
        public PontoDescarte pontodescarte { get; set; }
        public int itemId { get; set; }
        public Item item { get; set; }
    }
}