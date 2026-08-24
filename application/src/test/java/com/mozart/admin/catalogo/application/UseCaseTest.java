package com.mozart.admin.catalogo.application;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

public class UseCaseTest {

    @Test
    public void testCrateUseCase(){
        Assertions.assertNotNull(new UseCase());
        Assertions.assertNotNull((new UseCase().execute()));
    }
}
