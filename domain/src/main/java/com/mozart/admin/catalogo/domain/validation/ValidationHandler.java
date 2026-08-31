package com.mozart.admin.catalogo.domain.validation;

import java.util.List;

public interface ValidationHandler {

    ValidationHandler append(Error anError);

    ValidationHandler append(ValidationHandler anHandler);

    ValidationHandler validate(Validation aValidation);

    List<java.lang.Error> getErrors();

    default boolean hasError() {
        return getErrors() != null && !getErrors().isEmpty();
    }

    public interface Validation {
        void validate();
    }
}
