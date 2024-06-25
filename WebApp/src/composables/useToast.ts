import { reactive } from 'vue';

class Toast {
  public readonly current: {
    title: string;
    message: string;
    visible: boolean;
  };

  constructor() {
    this.current = reactive({
      title: '',
      message: '',
      visible: false
    });
  }

  public show(title: string, message: string): void {
    this.current.title = title;
    this.current.message = message;
    this.current.visible = true;

    setTimeout(() => (this.current.visible = false), 3000);
  }
}

let toast: Toast | null = null;

export default function useToast(): Toast {
  if (!toast) {
    toast = new Toast();
  }

  return toast;
}
