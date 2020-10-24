namespace e_descarte_api.Models
{
    public class PontoDescarteItem
    {
        public PontoDescarteItem() { }        
        public PontoDescarteItem(int id, int quant, int status, int totalponto, int pontodescarteId, int itemId, int usuarioId)
        {

            this.id = id;
            this.quant = quant;            
            this.status = status;            
            this.totalponto = totalponto;            
            this.pontodescarteId = pontodescarteId;
            this.itemId = itemId;
            this.usuarioId = usuarioId;
        }
        
        public int id { get; set; }
        public int quant { get; set; }
        public int status { get; set; }
        public int totalponto { get; set; }
        public int pontodescarteId { get; set; }
        public PontoDescarte pontodescarte { get; set; }
        public int itemId { get; set; }
        public Item item { get; set; }
        public int usuarioId { get; set; }
        public Usuario usuario { get; set; }
    }
}