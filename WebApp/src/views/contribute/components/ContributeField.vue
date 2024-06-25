<template>
  <label :for="inputId" class="form-label">{{ costType.name }}</label>
  <div class="input-group">
    <span class="input-group-text">R$</span>
    <input :id="inputId" ref="inputRef" class="form-control" @change="onChange" />
  </div>
  <div class="form-text text-truncate text-muted" :title="costType.description">
    {{ costType.description }}
  </div>
</template>

<script setup lang="ts">
import { computed, type PropType } from 'vue';
import type { ICostType } from '@/domain/costs';
import { CurrencyDisplay, useCurrencyInput } from 'vue-currency-input';

const props = defineProps({
  costType: {
    type: Object as PropType<ICostType>,
    required: true
  }
});

const { inputRef, numberValue } = useCurrencyInput(
  {
    locale: 'pt-BR',
    currency: 'BRL',
    currencyDisplay: CurrencyDisplay.hidden,
    valueRange: {
      min: 0,
      max: 999999
    },
    hideCurrencySymbolOnFocus: true,
    hideGroupingSeparatorOnFocus: false,
    hideNegligibleDecimalDigitsOnFocus: false,
    autoDecimalDigits: true,
    useGrouping: true,
    accountingSign: false
  },
  true
);

const inputId = computed(() => `input-${props.costType.id}`);

function onChange() {
  props!.costType.value = numberValue.value ?? 0;
}
</script>
