package com.mozart.admin.catalogo.infrastructure;

import com.mozart.admin.catalogo.application.UseCase;

public class Main {
    public static void main(String[] args) {
        System.out.println("Hello World");
        System.out.println(new UseCase().execute());
    }
}