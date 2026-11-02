const API_URL = import.meta.env.VITE_API_URL || 'http://localhost:5080/api';
export function getToken(){return localStorage.getItem('odvexa_token')}
export async function api(path, options={}){
 const headers={'Content-Type':'application/json',...(options.headers||{})};
 const token=getToken(); if(token) headers.Authorization=`Bearer ${token}`;
 const response=await fetch(`${API_URL}${path}`,{...options,headers});
 if(response.status===204)return null;
 const data=await response.json().catch(()=>null);
 if(!response.ok)throw new Error(data?.message||data?.title||'Request failed');
 return data;
}
export const authApi={
 login:(email,password)=>api('/auth/login',{method:'POST',body:JSON.stringify({email,password})}),
 register:(name,email,password)=>api('/auth/register',{method:'POST',body:JSON.stringify({name,email,password})})
};
