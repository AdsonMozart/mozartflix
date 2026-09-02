package com.mozart.admin.catalogo.application;

import com.mozart.admin.catalogo.domain.category.Category;

public class UseCase {

    public Category execute() {
        return Category.newCategory("Filme name", "Filme description", true);
    }
}