import axios, { type AxiosInstance } from 'axios';

class ApiClient {
  private readonly axiosInstance: AxiosInstance;

  constructor() {
    this.axiosInstance = axios.create({
      baseURL: import.meta.env.VITE_API_URL,
      withCredentials: false
    });
  }

  public async get<T>(url: string): Promise<T> {
    const response = await this.axiosInstance.get<T>(url);

    return response.data;
  }

  public async post<T>(url: string, data: any): Promise<T> {
    const response = await this.axiosInstance.post<T>(url, data);

    return response.data;
  }
}

let apiClient: ApiClient;

export function useApiClient(): ApiClient {
  if (!apiClient) {
    apiClient = new ApiClient();
  }

  return apiClient;
}
