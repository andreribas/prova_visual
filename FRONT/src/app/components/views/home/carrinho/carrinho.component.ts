import { Component, OnInit } from "@angular/core";
import { FormaPagamento } from "src/app/models/forma_pagamento";
import { ItemVenda } from "src/app/models/item-venda";
import { FormaPagamentoService } from "src/app/services/forma_pagamento.service";
import { ItemService } from "src/app/services/item.service";

@Component({
    selector: "app-carrinho",
    templateUrl: "./carrinho.component.html",
    styleUrls: ["./carrinho.component.css"],
})
export class CarrinhoComponent implements OnInit {
    itens: ItemVenda[] = [];
    nomeCliente: string = "";
    formasPagamento: FormaPagamento[] = [];
    formaPagamentoId!: number;
    colunasExibidas: String[] = ["nome", "preco", "quantidade", "imagem"];
    valorTotal!: number;
    constructor(private itemService: ItemService, private formaPagamentoService: FormaPagamentoService) {}

    ngOnInit(): void {
        let carrinhoId = localStorage.getItem("carrinhoId")! || "";
        this.itemService.getByCartId(carrinhoId).subscribe((itens) => {
            this.itens = itens;
            this.valorTotal = this.itens.reduce((total, item) => {
                return total + item.preco * item.quantidade;
            }, 0);
        });
        this.formaPagamentoService.list().subscribe((formasPagamento) => {
            this.formasPagamento = formasPagamento;
        });
    }
    finalizar(): void {
        
    }
}
