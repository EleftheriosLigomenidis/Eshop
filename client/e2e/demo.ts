let data: number | string = 42;

const car1 :ICar ={
    color:'blie',
    model:'bmw',
    
} 


interface ICar{
    color:string;
    model:string;
    topSpeed?:number;

}
const car2 :ICar = {
    color:'red',
    model:"mercedes",
    topSpeed:100
}

const multiply = (x:number,y:number) => x * y
