class Formatters {
  private readonly currencyFormatter = new Intl.NumberFormat('pt-BR', {
    style: 'currency',
    currency: 'BRL'
  });

  currency(value: number): string {
    return this.currencyFormatter.format(value);
  }
}

let formatters: Formatters | undefined;

export default function useFormatters(): Formatters {
  if (!formatters) {
    formatters = new Formatters();
  }

  return formatters;
}
